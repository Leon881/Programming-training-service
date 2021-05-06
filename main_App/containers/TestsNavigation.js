import React from 'react';
import { connect } from 'react-redux';
import TestsNavigation from '../components/TestsNavigation/TestsNavigation';
import { navigateToPage} from '../actionCreators';


export default connect(
    (state,props) => ({
        testsList : state.testsList
    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(TestsNavigation)