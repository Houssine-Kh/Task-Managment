import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_CONFIG } from '../core/api/api-config';

export interface Task {
  id: string;
  title: string;
  status: string;
  dueDate: string;
  assignedUserId?: string;
}

export interface Project {
  id: string;
  name: string;
  tasks: Task[];
}

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private apiUrl = API_CONFIG.BASE_URL + API_CONFIG.PROJECTS;

  constructor(private http: HttpClient) {}

  getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }

  getProjectById(id: string): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/${id}`);
  }

  createProject(name: string): Observable<string> {
    return this.http.post<string>(this.apiUrl, { name });
  }
}
