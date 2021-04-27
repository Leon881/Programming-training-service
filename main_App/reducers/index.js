import { combineReducers } from 'redux';
import { createReducer } from 'redux-create-reducer';
import Page from '../constants/Page';
import Status from '../constants/Status';
import * as actionTypes from '../actionTypes';


const pageReducer=createReducer(Page.mainMenu,{[actionTypes.NAVIGATE_TO_PAGE]:(state,action)=>action.page});
const accordionMenuReducer=createReducer({inf:[], status: Status.empty},
     {[actionTypes.LOAD_ACCORDION_MENU_INF_SUCCESS]:(state,action)=>({...state, inf:action.value, status: Status.loaded}),
     [actionTypes.LOAD_ACCORDION_MENU_INF_REQUEST]:(state,action)=>({...state, status: Status.loading})});

 const learningAreaReducer=createReducer({text:[], status: Status.empty},
     {[actionTypes.LOAD_LEARNING_TEXT_SUCCESS]:(state,action)=>({...state, text:action.text, status: Status.loaded}),
     [actionTypes.LOAD_LEARNING_TEXT_REQUEST]:(state,action)=>({...state, status: Status.loading})});

export const rootReducer = combineReducers({
    page: pageReducer,
    accordionMenu: accordionMenuReducer,
    learningArea: learningAreaReducer,
});