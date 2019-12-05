import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Moment from 'react-moment';
import { Button } from 'react-bootstrap';

const redirectToCarDetails = (Id, history) => {
    history.push('/CarDetails/' + Id);
}

const redirectToUpdateCar = (Id, history) => {
    history.push('/updateCar/' + Id);
}

const rediterctToDeleteCar = (Id, history) => {
    history.push('/deleteCar/' + Id);
}

const car = (props) => {
    return (
        <Aux>
            <tr>
                <td>{props.car.Id}</td>
                <td>>{props.car.Name}</td>
                <td>{props.car.Available}</td>
                <td>
                    <Button onClick={() => redirectToCarDetails(props.car.Id, props.history)}>Details</Button>
                </td>
                <td>
                    <Button bsStyle="success" onClick={() => redirectToUpdateCar(props.car.Id, props.history)}>Update</Button>
                </td>
                <td>
                    <Button bsStyle="danger" onClick={() => rediterctToDeleteCar(props.car.Id, props.history)}>Delete</Button>
                </td>
            </tr>
        </Aux>
    )
}

export default car;