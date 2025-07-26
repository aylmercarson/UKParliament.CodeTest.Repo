import { inject } from '@angular/core';
import { exhaustMap, pipe, tap } from 'rxjs';
import { patchState, signalStore, withHooks, withMethods } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import {
  addEntity,
  removeEntity,
  setAllEntities,
  withEntities,
} from '@ngrx/signals/entities';
import { tapResponse } from '@ngrx/operators';
import { PersonViewModel } from '../models/person-view-model';
import { PersonService } from '../services/person.service';
import { setError, setFulfilled, setPending, withRequestStatus } from './request-status-feature';

export const PersonStore = signalStore(
    { providedIn: 'root' },
    withEntities<PersonViewModel>(),
    withRequestStatus(),
    withMethods((store, service = inject(PersonService)) => ({
      removeUser(id:string): void {
        patchState(store, removeEntity(id));
      },
      addUser(user: PersonViewModel): void {
        patchState(store, addEntity(user));
      },
      loadUsers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, setPending())),
        exhaustMap(() => {
          return service.getAllPersons().pipe(
            tapResponse({
              next: (users) => {
                patchState(store, setAllEntities(users), setFulfilled());
              },
              error: (error: { message: string }) => {
                patchState(store, setError(error.message));
              },
            }),
          );
        }),
      ),
    ),
    })),
    withHooks({
      onInit(store) {
        store.loadUsers();
      },
    }),
);