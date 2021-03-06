﻿
    // This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
    // To modify this class, edit "1_ApiModels"
    // More info: http://frhagn.github.io/Typewriter/
    import { ConnectionTypeEnum } from './ConnectionTypeEnum';

    export interface Relay {
        /** Db Key [Type:Guid] */
        relayId/*Required*/: string;
        /** The hub Id this relay is connected to [Type:Guid] */
        hubId/*Required*/: string;
        /** UserId Guid. Will be overwrited on Insert and Update by the current userid [Type:string] */
        userId/*Required*/: string;
        /** The relay name. It's only to help you to figure what's this relay. [Type:string] */
        name/*Required*/: string;
        /** Usually the type of hardware this relay is hosted on [Arduino Uno,Mega,Yun, etc..] [Type:string] */
        hardWare?: string;
        /** The connection type used to communicate with the Hub [Type:ConnectionTypeEnum] */
        connectionType/*Required*/: ConnectionTypeEnum;
    }
    
