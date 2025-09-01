import { Routes } from '@angular/router';
import { ProjectComponent } from './components/project/project.component';


export const routes: Routes = [
  {
    path: '',
    component: ProjectComponent
  },
  // You can add more routes later, e.g. Users page
  // { path: 'users', component: UsersComponent }
];