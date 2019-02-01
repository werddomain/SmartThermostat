import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { homepageRoutingModule } from './homepage-routing.module';
import { homepageComponent } from './homepage.component';

import { PageHeaderModule, BreadCrumbModule } from './../../shared';
import { HomesService } from '@app/shared/services/Homes.service'
@NgModule({
    imports: [CommonModule, homepageRoutingModule, PageHeaderModule, BreadCrumbModule],
    declarations: [homepageComponent],
    providers: [HomesService]
})
export class homepageModule {}
