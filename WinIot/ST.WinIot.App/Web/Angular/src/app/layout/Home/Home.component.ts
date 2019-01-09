import { Component, OnInit } from '@angular/core';

import { HomesService } from "../../shared/services/Homes.service";
import { Home } from '../../shared/classes/Home';
@Component({
    selector: 'app-Home',
    templateUrl: './Home.component.html',
    styleUrls: ['./Home.component.less']
})
export class HomeComponent implements OnInit {
    constructor(private homeService: HomesService) {}
    Homes: Home[];

    ngOnInit() { }
    load() {
        this.homeService.getHomes().subscribe(h => {
            this.Homes = h;
        });
    }
}
