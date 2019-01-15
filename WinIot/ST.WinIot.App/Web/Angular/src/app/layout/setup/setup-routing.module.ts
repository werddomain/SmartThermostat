import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { setupComponent } from './setup.component';

const routes: Routes = [
    {
        path: '',
        component: setupComponent,
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'prefix' },
            { path: 'home', loadChildren: './home/home.module#homeModule' },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class setupRoutingModule {}
