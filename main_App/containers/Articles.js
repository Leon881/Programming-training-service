import React from 'react';
import { connect } from 'react-redux';
import Articles from '../components/Articles/Articles';

export default connect(
    (state, props) => ({
        text:state.text
    }),
    (dispatch, props) => ({
    })
)(Articles);