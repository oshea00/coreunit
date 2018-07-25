import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface CounterState {
    currCount: number;
}

export class Counter extends React.Component<RouteComponentProps<{}>, CounterState> {
    constructor() {
        super();
        this.state = { currCount: 0 };
    }

    public render() {
        return <div>
            <h1>Counter</h1>

            <p>A Simple example of a React component.</p>

            <p>Current count: <strong>{ this.state.currCount }</strong></p>

            <button onClick={ () => { this.incrementCounter() } }>Increment</button>
        </div>;
    }

    incrementCounter() {
        this.setState({
            currCount: this.state.currCount + 1
        });
    }
}
