import React from 'react';
import { connect } from 'react-redux';
import TestArea from '../components/TestArea/TestArea';
import { navigateToPage} from '../actionCreators';

export default connect(
    (state,props) => ({
        page: state.page
    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value))
    })
)(TestArea)