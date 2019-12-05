import React, { Component } from 'react';
import { Table, Col, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Car from '../../../components/CarComponents/Car/Car';
import { PropTypes } from 'react'

import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';

export class CarList extends Component {

    componentDidMount = () => {
        let url = '/api/car';
        this.props.onGetData(url, { ...this.props });
    }

    render() {
        let cars = [];
        if (this.props.data && this.props.data.length > 0) {
            cars = this.props.data.map((car) => {
                return (
                    <Car key={car.Id} car={car} {...this.props} />
                )
            })
        }

        return (
            <Aux>
                <Row>
                    <Col mdOffset={10} md={2}>
                        <Link to='/createCar' >CreateCar</Link>
                    </Col>
                </Row>
                <br />
                <Row>
                    <Col md={12}>
                        <Table responsive striped>
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Price</th>
                                    <th>Available</th>
                                    <th>Update</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                {cars}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.data
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(CarList);