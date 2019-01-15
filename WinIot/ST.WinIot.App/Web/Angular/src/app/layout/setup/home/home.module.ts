import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { homeRoutingModule } from './home-routing.module';
import { homeComponent } from './home.component';

@NgModule({
    imports: [CommonModule, homeRoutingModule],
    declarations: [homeComponent]
})
export class homeModule {}
