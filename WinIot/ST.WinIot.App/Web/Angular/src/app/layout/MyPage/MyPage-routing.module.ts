import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyPageComponent } from './MyPage.component';

const routes: Routes = [
    {
        path: '',
		component: MyPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MyPageRoutingModule {}
