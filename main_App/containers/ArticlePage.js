import React from 'react';
import { connect } from 'react-redux';
import ArticlePage from '../components/ArticlePage/ArticlePage';
import { navigateToPage } from '../actionCreators';


export default connect(
    (state,props) => ({
    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value)),
    })
)(ArticlePage)