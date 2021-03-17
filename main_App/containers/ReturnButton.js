import React from 'react';
import { connect } from 'react-redux';
import { navigateTo } from '../actionCreators';
import ReturnButton from '../components/ReturnButton/ReturnButton';


export default connect(
    (state,props) => ({
    }),
    (dispatch,props) =>({
        onNavigate: value => dispatch(navigateTo(value))
    })
)(ReturnButton)