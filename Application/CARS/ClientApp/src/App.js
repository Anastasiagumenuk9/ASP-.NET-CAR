import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { MyAccount } from './components/MyAccount';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import {CarList} from './containers/Car/CarList/CarList';
import axios from 'axios';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/myaccount' component={MyAccount} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetchdata' component={FetchData} />
            <Route path='/carlist' component={CarList} />
      </Layout>
    );
  }
}
