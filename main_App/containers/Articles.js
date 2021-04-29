import React from 'react';
import { connect } from 'react-redux';
import Articles from '../components/Articles/Articles';
import { navigateToPage} from '../actionCreators';

export default connect(
    (state, props) => ({
        articlesList: state.articlesList
    }),
    (dispatch, props) => ({
        onNavigateToPage: value => dispatch(navigateToPage(value)),
    })
)(Articles);