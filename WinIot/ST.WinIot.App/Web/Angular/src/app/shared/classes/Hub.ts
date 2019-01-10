﻿
    // This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
    // To modify this class, edit "1_ApiModels"
    // More info: http://frhagn.github.io/Typewriter/
    import { Piece } from './Piece';
import { Device } from './Device';
import { Relay } from './Relay';

    export interface Hub {
        hubId: string;
        userId: string;
        homeId: string;
        hardware: string;
        pieceId: string;
        piece: Piece;
        devices: Device[];
        relays: Relay[];
    }
    
