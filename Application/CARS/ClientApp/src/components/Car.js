import React, { Component } from 'react';
import ReactDOM from 'react-dom'
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom'; 
import axios from 'axios';


/*
export class Car extends Component {

    constructor(props) {
        super(props);
        this.state = { cars: []};
    }

    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const cars = JSON.parse(xhr.responseText);
            this.setState({ cars: cars });
        };
        xhr.send();
    }


    // Returns the HTML table to the render() method.  
         renderCarsTable(cars) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Available</th>                 
                </tr>
            </thead>
            <tbody>  
                <tr>
                    <td></td>
                    <td>{this.state.cars.Id}</td>
                    <td>{this.state.cars.Name}</td>
                    <td>{this.state.cars.Price}</td>
                    <td>{this.state.cars.Available}</td>
                    </tr>
            </tbody>
        </table>;
    }  

     render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCarsTable(this.state.cars);
        return <div>
            <h1>Car Data</h1>
            <p>This component demonstrates fetching Employee data from the server.</p>
            {contents}
        </div>;
    }  
    }
    
 export class CarsList extends React.Component {
    constructor() {
        super();
        this.state = {
            CarData: []
        }
    }

    componentDidMount() {
        axios.get("http://localhost:44325/api/cars").then(response => {
            //console.log(response.data);  
            this.setState({
                CarData: response.data
            });
        });
    }

    render() {

        return (
            <section>
                <h1>Products List</h1>
                <div>
                    <table>
                        <thead><tr><th>Car Id</th><th>Car Name</th><th>Car Price</th></tr></thead>
                        <tbody>
                            {
                                this.state.CartData.map((p, index) => {
                                    return <tr key={index}><td>{p.Id}</td><td> {p.Name}</td><td>{p.Price}</td></tr>;
                                })
                            }
                        </tbody>
                    </table>
                </div>


            </section>
        )
    }
}

ReactDOM.render(
    <CarsList />,
    document.getElementById('content'));  

*/
