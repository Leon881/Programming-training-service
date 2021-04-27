import React from 'react';
import { connect } from 'react-redux';
import AccordionMenu from '../components/AccordionMenu/AccordionMenu';
import { navigateToPage, setLearningText, requestLearningText } from '../actionCreators';

export default connect(
    (state, props) => ({
        accordionMenu: state.accordionMenu,
        learningArea: state.learningArea,
        page: state.page,
    }),
    (dispatch, props) => ({
        onNavigateToPage: value => dispatch(navigateToPage(value)),
        setLearningText: text => dispatch(setLearningText(text)),
        requestLearningText: () => dispatch(requestLearningText()),
    })
)(AccordionMenu);