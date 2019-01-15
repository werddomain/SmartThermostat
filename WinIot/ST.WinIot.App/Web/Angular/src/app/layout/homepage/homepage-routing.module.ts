import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { homepageComponent } from './homepage.component';

const routes: Routes = [
    {
        path: '',
		component: homepageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class homepageRoutingModule {}
