import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { homeRoutingModule } from './home-routing.module';
import { homeComponent } from './home.component';

@NgModule({
    imports: [CommonModule, homeRoutingModule, FormsModule, ReactiveFormsModule],
    declarations: [homeComponent]
})
export class homeModule {}
