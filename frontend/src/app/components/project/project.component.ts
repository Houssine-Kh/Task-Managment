import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { ProjectService, Project } from '../../services/project.service';

@Component({
  selector: 'app-project',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
        MatChipsModule
  ],
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {
  projects: Project[] = [];
  newProjectName = '';
  displayedColumns: string[] = ['name', 'tasks'];

  constructor(private projectService: ProjectService) {}

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() {
    this.projectService.getAllProjects().subscribe(res => this.projects = res);
  }

  createProject() {
    if (!this.newProjectName.trim()) return;
    this.projectService.createProject(this.newProjectName).subscribe(() => {
      this.newProjectName = '';
      this.loadProjects();
    });
  }

    getChipColor(status: string): string {
    switch (status.toLowerCase()) {
      case 'pending': return 'warn';
      case 'completed': return 'primary';
      default: return 'accent';
    }
  }
}
