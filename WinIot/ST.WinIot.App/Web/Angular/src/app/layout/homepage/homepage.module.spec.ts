import { homepageModule } from './homepage.module';

describe('homepageModule', () => {
    let _homepageModule: homepageModule;

    beforeEach(() => {
        _homepageModule = new homepageModule();
    });

    it('should create an instance', () => {
        expect(homepageModule).toBeTruthy();
    });
});
