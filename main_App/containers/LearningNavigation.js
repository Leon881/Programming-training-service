import React from 'react';
import { connect } from 'react-redux';
import LearningNavigation from '../components/LearningNavigation/LearningNavigation';
import { navigateToPage } from '../actionCreators';

export default connect(
    (state,props) => ({

    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(LearningNavigation)