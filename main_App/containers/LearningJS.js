import React from 'react';
import { connect } from 'react-redux';
import LearningJS from '../components/LearningJS/LearningJS';
import { navigateToPage } from '../actionCreators';

export default connect(
    (state,props) => ({

    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(LearningJS)