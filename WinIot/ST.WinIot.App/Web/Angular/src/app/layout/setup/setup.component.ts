import { Component, OnInit, NgZone } from '@angular/core';
import { SetupService } from "./setup.service"
import { BreadCrumbItem } from '../../shared/modules/bread-crumb/bread-crumb.component';

@Component({
    selector: 'app-setup',
    templateUrl: './setup.component.html',
    styleUrls: ['./setup.component.less']
})
export class setupComponent implements OnInit {
    constructor(private setupService: SetupService, private zone: NgZone) {
        this.setupService.fireBreadCrumbItemChanged.subscribe(o => {
           
                this.BreadCrumbs = o;
                console.log('breadCrumb recived on Setup', o);
        });
        this.setupService.fireHeadlingChanged.subscribe(o => {
            this.heading = o;
        });
    }
    public BreadCrumbs: BreadCrumbItem[]
    public heading: string;

    ngOnInit() {
        this.BreadCrumbs = [{
            active: false,
            icon: "fa-cogs",
            name: "Setup",
            route: "/setup"
        }];
        this.setupService.SetBreadCrumb(this.BreadCrumbs);
    }
}
