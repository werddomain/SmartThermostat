import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { BreadCrumbModule } from './../../shared';
import { BreadCrumbItem } from '../../shared/modules/bread-crumb/bread-crumb.component';
import { HomesService, IApiError } from "@app/shared/services/"
import { i18nApply } from '@angular/core/src/render3';
@Component({
    selector: 'app-homepage',
    templateUrl: './homepage.component.html',
    styleUrls: ['./homepage.component.less']
})
export class homepageComponent implements OnInit {
    breadCrumbItems: Array<BreadCrumbItem>;

    constructor(private homesService: HomesService, private router: Router) {
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

    ngOnInit() {
        this.homesService.getHomes().subscribe(o => {
            if (o == null || o.length == 0)
                this.router.navigate(['/setup']);
        }, error => {
            let e: IApiError = error;
            if (e.httpError.status == 404)
                this.router.navigate(['/setup']);
            
            });
    }
}
