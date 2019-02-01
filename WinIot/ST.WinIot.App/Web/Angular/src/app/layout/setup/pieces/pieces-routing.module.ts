import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { piecesComponent } from './pieces.component';

const routes: Routes = [
    {
        path: '',
		component: piecesComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class piecesRoutingModule {}
