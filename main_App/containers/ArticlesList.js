import React from 'react';
import { connect } from 'react-redux';
import ArticlesList from '../components/ArticlesList/ArticleList';
import {setInformation} from '../actionCreators'

export default connect(
    (state, props) => ({
        articles:state.articlesList
    }),
    (dispatch, props) => ({
        onArticleClik:(text) => dispatch(setInformation(text)),
    })
)(ArticlesList);