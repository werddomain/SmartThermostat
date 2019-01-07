﻿
    // This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
    // To modify this class, edit "1_ApiModels"
    // More info: http://frhagn.github.io/Typewriter/
    import { DeviceType } from './DeviceType';
import { DeviceTrait } from './DeviceTrait';
import { DeviceNickName } from './DeviceNickName';
import { Hub } from './Hub';
import { Relay } from './Relay';
import { Piece } from './Piece';

    export interface Device {
        DeviceId: string;
        UserId: string;
        RelayId?: string;
        HubId: string;
        PieceId: string;
        Name: string;
        ArduinoId: number;
        DeviceType: DeviceType;
        Traits: DeviceTrait[];
        NickNames: DeviceNickName[];
        Hub: Hub;
        Relay: Relay;
        Piece: Piece;
    }
    
