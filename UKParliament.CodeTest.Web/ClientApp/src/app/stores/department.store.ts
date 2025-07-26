import { inject } from "@angular/core";
import { tapResponse } from "@ngrx/operators";
import { patchState, signalStore, withHooks, withMethods } from "@ngrx/signals";
import { addEntity, removeEntity, setAllEntities, withEntities } from "@ngrx/signals/entities";
import { rxMethod } from "@ngrx/signals/rxjs-interop";
import { exhaustMap, pipe, tap } from "rxjs";
import { Department } from "../models/department";
import { DepartmentService } from "../services/department.service";
import { withRequestStatus, setPending, setFulfilled, setError } from "./request-status-feature";


export const DepartmentStore = signalStore(
    { providedIn: 'root' },
    withEntities<Department>(),
    withRequestStatus(),
    withMethods((store, service = inject(DepartmentService)) => ({
      removeDepartment(id:string): void {
        patchState(store, removeEntity(id));
      },
      addDepartment(department: Department): void {
        patchState(store, addEntity(department));
      },
      getNameByDeptId(id: number){
        return store.entityMap()[id]?.name;
      },
      loadDepartments: rxMethod<void>(
      pipe(
        tap(() => patchState(store, setPending())),
        exhaustMap(() => {
          return service.getAllDepartments().pipe(
            tapResponse({
              next: (departments) => {
                patchState(store, setAllEntities(departments), setFulfilled());
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
        store.loadDepartments();
      },
    }),
);