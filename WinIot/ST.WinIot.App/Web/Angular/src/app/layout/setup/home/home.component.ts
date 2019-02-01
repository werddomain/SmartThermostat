import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { Router } from '@angular/router';
import { SetupService } from "../setup.service"
import { Home, Piece, PieceTypeEnum } from '@app/shared/classes'
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { HomesService } from '@app/shared/services/Homes.service'
import { Observable } from 'rxjs';
@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.less']
})
export class homeComponent implements OnInit {
   
    constructor(private router: Router, private setupService: SetupService, private homesService: HomesService ) {
        
        this.home = {
            city: "",
            country: "",
            fullAddress: "",
            homeId: "",
            name: "",
            state: ""
        };
        
    }
    home: Home;
    


    ngOnInit() {
        console.log("home.ngOnInit()");
        this.setupService.setHeadling("Home");
        this.setupService.ActivateBreadCrumb({
            active: true,
            icon: "fa-home",
            name: "Home",
            route: "/setup/home"
        });
        if (this.setupService.CurrentHome != null) {
            this.home = this.setupService.CurrentHome;
        }
        else
        {
            this.homesService.getHomes().subscribe(home => {
                if (home != null && home.length > 0) {
                    this.setupService.CurrentHome = home[0];
                    this.home = home[0];
                    this.setupService.homeSaved = true;
                }
            });
        }
        
        

        
    }
    
    EndMessage: string;
    private ServiceError(error: any) {
        this.EndMessage = error;
    }
    private ServiceSaved(home: Home) {
        this.home = home;
        this.setupService.CurrentHome = home;
        this.setupService.homeSaved = true;
        this.router.navigate(['/setup/pieces']);
    }
    Next() {
        
        if (this.setupService.homeSaved)
            this.homesService.putHome(this.home.homeId, this.home).subscribe(
                () => {
                    //Completed
                    this.ServiceSaved(this.home);
                },
                error => {
                    this.ServiceError(error);
                },
            );
        else
            this.homesService.postHome(this.home).subscribe(
                (home) => {
                    this.ServiceSaved(home);
                },
                error => {
                    this.ServiceError(error);
                });

    }
   
}

