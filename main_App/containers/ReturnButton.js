import React from 'react';
import { connect } from 'react-redux';
import { navigateToPage } from '../actionCreators';
import ReturnButton from '../components/ReturnButton/ReturnButton';


export default connect(
    (state,props) => ({
    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(ReturnButton)