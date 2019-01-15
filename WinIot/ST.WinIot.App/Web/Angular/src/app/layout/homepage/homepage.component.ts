import { Component, OnInit } from '@angular/core';
import { BreadCrumbModule } from './../../shared';
import {BreadCrumbItem } from '../../shared/modules/bread-crumb/bread-crumb.component';
@Component({
    selector: 'app-homepage',
    templateUrl: './homepage.component.html',
    styleUrls: ['./homepage.component.less']
})
export class homepageComponent implements OnInit {
    breadCrumbItems: Array<BreadCrumbItem>;

    constructor() {
        this.breadCrumbItems = [
            {
                name: "home",
                active: false,
                icon: "fa-home",
                route: "/home"
            },
            {
                name: "current",
                active: true,
                icon: "fa-anchor",
                route:null
            }
        ];
    }

    ngOnInit() {}
}
