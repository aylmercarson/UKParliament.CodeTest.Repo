import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Department } from '../models/department';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
    private http = inject(HttpClient)
    baseUrl = environment.baseUrl;

    getAllDepartments(): Observable<Department[]> {
        return this.http.get<Department[]>(this.baseUrl + 'api/department/getall');
    }
}
