import { HomeModule } from './Home.module';

describe('HomeModule', () => {
    let _HomeModule: HomeModule;

    beforeEach(() => {
        _HomeModule = new HomeModule();
    });

    it('should create an instance', () => {
        expect(HomeModule).toBeTruthy();
    });
});
