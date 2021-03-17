import React from 'react';
import { connect } from 'react-redux';
import NavigationMenu from '../components/NavigationMenu/NavigationMenu';
import { navigateTo } from '../actionCreators';

export default connect(
    (state,props) => ({

    }),
    (dispatch,props) =>({
        onNavigate: value => dispatch(navigateTo(value))
    })
)(NavigationMenu)