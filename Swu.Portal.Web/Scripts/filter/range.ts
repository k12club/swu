module Swu {
    export function rangeFilter() {
        return function (input: number[], total: number) {
            for (var i = 0; i < total; i++) {
                input.push(i);
            }
            return input;
        };
    }
}