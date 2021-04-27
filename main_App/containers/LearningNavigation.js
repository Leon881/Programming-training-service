import React from 'react';
import { connect } from 'react-redux';
import LearningNavigation from '../components/LearningNavigation/LearningNavigation';
import { navigateToPage,setAccordionMenuInf, requestAccordionMenuInf} from '../actionCreators';

export default connect(
    (state,props) => ({

    }),
    (dispatch,props) =>({
        onNavigateToPage: value => dispatch(navigateToPage(value)),
        setAccordionMenu: value => dispatch(setAccordionMenuInf(value)),
        requestAccordionMenu: () => dispatch(requestAccordionMenuInf()),
    })
)(LearningNavigation)