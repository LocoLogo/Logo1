import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from "./components/Header/header.component";
import { ProfileComponent } from "./components/Profile/profile.component";
import { ProjectComponent } from "./components/Project/project.component";
import { UploadComponent } from "./components/Upload/upload.component";
import { LoginComponent } from "./components/Login/login.component";

const appRoutes: Routes = [
    {
        path: "",
        component: LoginComponent
    },
    {
        path: "home",
        redirectTo: ""
    },
    {
        path: "profile",
        component: ProfileComponent
    },
    {
        path: "upload",
        component: UploadComponent
    },
    {
        path: "project",
        component: ProjectComponent
    }
];

export const AppRoutingProviders: any[] = [
];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);