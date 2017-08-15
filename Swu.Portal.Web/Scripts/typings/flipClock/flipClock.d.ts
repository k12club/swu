interface IFlipClockConfig {
    autoStart?: boolean;
    countdown?: boolean;
    callbacks?: {
        destroy?: Function,
        create?: Function,
        init?: Function,
        interval?: Function,
        start?: Function,
        stop?: Function,
        reset?: Function
    };
    classes?: {};
    clockFace?: string;
    defaultClockFace?: string;
    defaultLanguage?: string;
}

interface IFlipClock {
    start: Function;
    stop: Function;
    setTime: (time: Date) => IFlipClock;
    setCountdown: (countdown: boolean) => IFlipClock;
    getTime(): Date;
}

//interface IFlipClockStatic {
//    new (digits: number, config?: IFlipClockConfig);
//}

interface JQuery {
    FlipClock?: (config?: IFlipClockConfig) => IFlipClock;
}