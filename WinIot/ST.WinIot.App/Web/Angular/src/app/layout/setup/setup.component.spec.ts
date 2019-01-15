import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { setupComponent } from './setup.component';

describe('setupComponent', () => {
	let component: setupComponent;
	let fixture: ComponentFixture<setupComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
				declarations: [setupComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
		fixture = TestBed.createComponent(setupComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
