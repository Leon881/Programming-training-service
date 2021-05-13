import React from 'react';
import { connect } from 'react-redux';
import TestArea from '../components/TestArea/TestArea';
import { navigateToPage, setTestResult} from '../actionCreators';

export default connect(
    (state,props) => ({
        page: state.page,
        test: state.test,
        testResult: state.testResult
    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value)),
        setTestResult: value => dispatch(setTestResult(value)),
    })
)(TestArea)