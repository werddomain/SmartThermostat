﻿
    // This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
    // To modify this class, edit "1_ApiModels"
    // More info: http://frhagn.github.io/Typewriter/
    import { Hub } from './Hub';
import { ConnectionTypeEnum } from './ConnectionTypeEnum';

    export interface Relay {
        relayId: string;
        hubId: string;
        hub: Hub;
        userId: string;
        name: string;
        hardWare: string;
        connectionType: ConnectionTypeEnum;
    }
    
