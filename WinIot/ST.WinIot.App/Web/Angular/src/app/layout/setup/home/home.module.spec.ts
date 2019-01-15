import { homeModule } from './home.module';

describe('homeModule', () => {
    let _homeModule: homeModule;

    beforeEach(() => {
        _homeModule = new homeModule();
    });

    it('should create an instance', () => {
        expect(homeModule).toBeTruthy();
    });
});
