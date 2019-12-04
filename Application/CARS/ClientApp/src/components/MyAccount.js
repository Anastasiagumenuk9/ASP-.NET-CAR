import React, { Component } from 'react';

export class MyAccount extends Component {
    displayName = MyAccount.name

    render() {
        return (
            <div>
                <form className="commentForm">
                    <p></p>
                    <input type="text" placeholder="Your Login " />
                    <p></p>
                    <input type="text" placeholder="Your Password " />
                    <p></p>
                    <input type="submit" value="Post" />
                </form>
            </div>
        );
    }
}