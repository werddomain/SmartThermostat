/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BreadCrumbComponent } from './bread-crumb.component';

let component: BreadCrumbComponent;
let fixture: ComponentFixture<BreadCrumbComponent>;

describe('bread-crumb component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BreadCrumbComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BreadCrumbComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});