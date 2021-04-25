import React from 'react';
import { connect } from 'react-redux';
import LearningSharp from '../components/LearningSharp/LearningSharp';
import { navigateToPage } from '../actionCreators';

export default connect(
    (state,props) => ({

    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(LearningSharp)