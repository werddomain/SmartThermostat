﻿
    // This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
    // To modify this class, edit "1_ApiModels"
    // More info: http://frhagn.github.io/Typewriter/
    
    export interface GoogleUser {
        /**  [Type:Guid] */
        googleUserId/*Required*/: string;
        /**  [Type:string] */
        userId?: string;
        /**  [Type:boolean] */
        active/*Required*/: boolean;
        /**  [Type:Date] */
        activationDate/*Required*/: Date;
    }
    
