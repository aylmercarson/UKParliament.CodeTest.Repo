import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonViewModel } from '../models/person-view-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private http = inject(HttpClient)
  baseUrl = environment.baseUrl;

  getPersonById(personId: string): Observable<PersonViewModel> {
    return this.http.get<PersonViewModel>(this.baseUrl + `api/person/${personId}`)
  }

  getAllPersons(): Observable<PersonViewModel[]> {
      return this.http.get<PersonViewModel[]>(this.baseUrl + 'api/person/getall');
  }

  addPerson(person: PersonViewModel): Observable<Response>{
      return this.http.post<Response>(this.baseUrl + 'api/person/add', person);
  }

  updatePerson(person: PersonViewModel): Observable<Response>{
      return this.http.put<Response>(this.baseUrl + 'api/person/update', person);
  }

  deletePerson(personId: string): Observable<Response>{
      return this.http.delete<Response>(this.baseUrl + `api/person/delete/${personId}`);
  }
}
