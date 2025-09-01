import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_CONFIG } from '../core/api/api-config';
import { Task } from './project.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = API_CONFIG.BASE_URL + API_CONFIG.TASKS;

  constructor(private http: HttpClient) {}

  addTask(title: string, dueDate: string, projectId: string): Observable<string> {
    return this.http.post<string>(this.apiUrl, { title, dueDateUtc: dueDate, projectId });
  }

  completeTask(taskId: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${taskId}/complete`, { taskId });
  }

  assignTask(taskId: string, userId: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${taskId}/assign`, { taskId, userId });
  }

  getTasksByProject(projectId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}/project/${projectId}`);
  }
}
