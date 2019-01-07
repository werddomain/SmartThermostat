import { Injectable } from '@angular/core';
import { MyAngularConfig } from "./shared/classes/MyAngularConfig";

@Injectable()
export class GlobalService {
    constructor() {
        
    }
    ApiConfig: MyAngularConfig;
}
