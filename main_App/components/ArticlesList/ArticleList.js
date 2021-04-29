import React, {useState, useRef, useEffect} from "react";
import PropTypes from 'prop-types';

export default function ArticlesList({articles=[],onArticleClik}) {
    debugger;
    let result = []

    const articleClik1=async (e)=>{
        let newText = await (await fetch('api/lessons/1')).text();
        await onArticleClik(newText)
    }
    const articleClik2=async (e)=>{
        let newText = await (await fetch('api/lessons/2')).text();
        await onArticleClik(newText)
    }
    const articleClik3=async (e)=>{
        let newText = await (await fetch('api/lessons/3')).text();
        await onArticleClik(newText)
    }

    result.push(<div onClick={articleClik1} >{articles[0].name}</div> );
    result.push(<div onClick={articleClik2} >{articles[1].name}</div> );
    result.push(<div onClick={articleClik3} >{articles[2].name}</div> );

    
    return (
        <div id='form' className='container-info'>
            {result}
        </div>
    )
}

ArticlesList.propTypes = {
    articles: PropTypes.array.isRequired,
    onArticleClik: PropTypes.func.isRequired
};