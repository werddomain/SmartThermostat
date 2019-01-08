import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyPageRoutingModule } from './MyPage-routing.module';
import { MyPageComponent } from './MyPage.component';

@NgModule({
    imports: [CommonModule, MyPageRoutingModule],
    declarations: [MyPageComponent]
})
export class MyPageModule {}
